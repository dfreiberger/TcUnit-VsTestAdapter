﻿using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace TcUnit.TestAdapter.RunSettings
{
    public static class RunSettingsExtensions
    {
        public static RunSettingsProvider GetTestSettingsProvider(this IRunSettings runSettings, string name)
        {
            return runSettings.GetSettings(name) as RunSettingsProvider;
        }

        public static TestSettings GetTestSettings(this IRunSettings runSettings, string name)
        {
            var provider = runSettings.GetTestSettingsProvider(name);
            if (provider == null)
            {
                // no runsettings file specified - use default values
                return new TestSettings
                {
                    Target = TestAdapter.DefaultTargetRuntime,
                    CleanUpAfterTestRun = TestAdapter.DefaultCleanUpAfterTestRun
                };
            }

            return provider.Settings as TestSettings;
        }
    }
}
