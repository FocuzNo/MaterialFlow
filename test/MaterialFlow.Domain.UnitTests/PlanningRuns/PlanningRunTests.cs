using MaterialFlow.Domain.PlanningRuns;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.UnitTests.Infrastructure;
using MaterialFlow.Domain.UnitTests.PlanningRunLines;

namespace MaterialFlow.Domain.UnitTests.PlanningRuns;

public sealed class PlanningRunTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeRun_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var runTimestamp = new DateTime(2025, 11, 15, 14, 30, 0, DateTimeKind.Utc);
        var siteId = Guid.NewGuid();
        var planningAreaId = Guid.NewGuid();
        var planningHorizon = 180;
        var startedByUser = "john.smith@company.com";
        var orderStatus = OrderStatus.Created;

        var run = PlanningRun.Create(
            id,
            runTimestamp,
            siteId,
            planningAreaId,
            planningHorizon,
            startedByUser,
            orderStatus);

        run.Id.Should().Be(id);
        run.RunTimestampUtc.Should().Be(runTimestamp);
        run.SiteId.Should().Be(siteId);
        run.PlanningAreaId.Should().Be(planningAreaId);
        run.PlanningHorizonInDays.Should().Be(planningHorizon);
        run.StartedByUser.Should().Be(startedByUser);
        run.OrderStatus.Should().Be(orderStatus);
        run.Lines.Should().BeEmpty();
    }

    [Fact]
    public void Create_WithoutSiteAndPlanningArea_ShouldBeNull()
    {
        var run = PlanningRunData.CreateRun();

        run.SiteId.Should().BeNull();
        run.Site.Should().BeNull();
        run.PlanningAreaId.Should().BeNull();
        run.PlanningArea.Should().BeNull();
    }

    [Fact]
    public void Create_WithShortPlanningHorizon_ShouldStoreCorrectly()
    {
        var run = PlanningRunData.CreateRun(
            planningHorizonInDays: 30,
            startedByUser: "scheduler.bot");

        run.PlanningHorizonInDays.Should().Be(30);
    }

    [Fact]
    public void Create_WithLongPlanningHorizon_ShouldStoreCorrectly()
    {
        var run = PlanningRunData.CreateRun(
            planningHorizonInDays: 365,
            startedByUser: "annual.planner@enterprise.com");

        run.PlanningHorizonInDays.Should().Be(365);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var run = PlanningRunData.CreateRun();
        var newPlanningHorizon = 120;
        var newOrderStatus = OrderStatus.Open;

        run.Update(newPlanningHorizon, newOrderStatus);

        run.PlanningHorizonInDays.Should().Be(newPlanningHorizon);
        run.OrderStatus.Should().Be(newOrderStatus);
    }

    [Fact]
    public void Update_ShouldNotModify_ImmutableProperties()
    {
        var run = PlanningRunData.CreateRun();
        var originalRunTimestamp = run.RunTimestampUtc;
        var originalSiteId = run.SiteId;
        var originalPlanningAreaId = run.PlanningAreaId;
        var originalStartedByUser = run.StartedByUser;

        run.Update(240, OrderStatus.Closed);

        run.RunTimestampUtc.Should().Be(originalRunTimestamp);
        run.SiteId.Should().Be(originalSiteId);
        run.PlanningAreaId.Should().Be(originalPlanningAreaId);
        run.StartedByUser.Should().Be(originalStartedByUser);
    }

    [Fact]
    public void AddLine_ShouldAddToCollection()
    {
        var run = PlanningRunData.CreateRun();
        var line = PlanningRunLineData.CreateLine(planningRunId: run.Id);

        run.AddLine(line);

        run.Lines.Should().ContainSingle();
        run.Lines.Should().Contain(line);
    }

    [Fact]
    public void AddLine_MultipleLines_ShouldAddAllToCollection()
    {
        var run = PlanningRunData.CreateRun();
        var line1 = PlanningRunLineData.CreateLine(planningRunId: run.Id);
        var line2 = PlanningRunLineData.CreateLine(planningRunId: run.Id);
        var line3 = PlanningRunLineData.CreateLine(planningRunId: run.Id);

        run.AddLine(line1);
        run.AddLine(line2);
        run.AddLine(line3);

        run.Lines.Should().HaveCount(3);
        run.Lines.Should().Contain(new[] { line1, line2, line3 });
    }

    [Fact]
    public void AddLine_ShouldMaintainOrderOfAddition()
    {
        var run = PlanningRunData.CreateRun();
        var line1 = PlanningRunLineData.CreateLine(
            planningRunId: run.Id,
            recommendedAction: "First Action");
        var line2 = PlanningRunLineData.CreateLine(
            planningRunId: run.Id,
            recommendedAction: "Second Action");
        var line3 = PlanningRunLineData.CreateLine(
            planningRunId: run.Id,
            recommendedAction: "Third Action");

        run.AddLine(line1);
        run.AddLine(line2);
        run.AddLine(line3);

        run.Lines.ElementAt(0).Should().Be(line1);
        run.Lines.ElementAt(1).Should().Be(line2);
        run.Lines.ElementAt(2).Should().Be(line3);
    }

    [Fact]
    public void Create_WithSystemUser_ShouldStoreCorrectly()
    {
        var run = PlanningRunData.CreateRun(
            startedByUser: "SYSTEM",
            orderStatus: OrderStatus.Created);

        run.StartedByUser.Should().Be("SYSTEM");
    }

    [Fact]
    public void Create_WithEmailAsUser_ShouldStoreCorrectly()
    {
        var run = PlanningRunData.CreateRun(
            startedByUser: "maria.garcia@manufacturing.com");

        run.StartedByUser.Should().Be("maria.garcia@manufacturing.com");
    }

    [Fact]
    public void Update_FromCreatedToClosed_ShouldUpdateStatus()
    {
        var run = PlanningRunData.CreateRun(orderStatus: OrderStatus.Created);

        run.Update(90, OrderStatus.Closed);

        run.OrderStatus.Should().Be(OrderStatus.Closed);
    }

    [Fact]
    public void Create_WithPreciseTimestamp_ShouldStoreExactTime()
    {
        var preciseTimestamp = new DateTime(2025, 12, 25, 23, 59, 59, 999, DateTimeKind.Utc);

        var run = PlanningRunData.CreateRun(runTimestampUtc: preciseTimestamp);

        run.RunTimestampUtc.Should().Be(preciseTimestamp);
        run.RunTimestampUtc.Kind.Should().Be(DateTimeKind.Utc);
    }
}