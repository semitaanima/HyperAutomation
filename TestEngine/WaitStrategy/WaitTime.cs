namespace TestEngine.WaitStrategy
{
    internal enum WaitTime
    {
        NoWait = 0,
        VeryShort = 100,
        DefaultMilliseconds = 200,
        Short = 1000,
        Medium = 2000,
        Long = 4000,
        VeryLong = 8000,
        QuiteLong = 16000,
        ExtremelyLong = 30000
    }
}