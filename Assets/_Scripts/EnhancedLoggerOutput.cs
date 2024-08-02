using UnityEngine;

public class EnhancedLoggerOutput : MonoBehaviour
{
    void Start()
    {
        EnhancedLogger.Log("This is an informational message.", EnhancedLogger.LogLevel.Info);
        EnhancedLogger.Log("This is a warning message.", EnhancedLogger.LogLevel.Warning);
        EnhancedLogger.Log("This is an error message.", EnhancedLogger.LogLevel.Error);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnhancedLogger.Log("Space key was pressed.", EnhancedLogger.LogLevel.Info);
        }
    }
}
