using System;
using UnityEngine;

public static class EnhancedLogger
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public static void Log(string message, LogLevel logLevel = LogLevel.Info)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string logMessage = $"[{timestamp}] [{logLevel}] {message}";

        switch (logLevel)
        {
            case LogLevel.Info:
                Debug.Log(logMessage);
                break;
            case LogLevel.Warning:
                Debug.LogWarning(logMessage);
                break;
            case LogLevel.Error:
                Debug.LogError(logMessage);
                break;
        }
    }
}
