using FluentAssertions;
using FluentAssertions.Execution;

namespace ClioSDK.Tests.TestHelpers;

public static class Times
{
    public static OccurredOnceAssertion Once()
    {
        return FluentAssertions.Times.Once();
    }
    
    public static OccurredExactlyAssertion Exactly(int count)
    {
        return FluentAssertions.Times.Exactly(count);
    }
    
    public static OccurredAtMostAssertion AtMost(int count)
    {
        return FluentAssertions.Times.AtMost(count);
    }
    
    public static OccurredAtLeastAssertion AtLeast(int count)
    {
        return FluentAssertions.Times.AtLeast(count);
    }
    
    public static OccurredNeverAssertion Never()
    {
        return FluentAssertions.Times.Never();
    }
}