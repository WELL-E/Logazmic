﻿namespace Logazmic
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Caliburn.Micro;

    using Logazmic.Services;
    using Logazmic.ViewModels;

    using Squirrel;

    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
            IoC.Get<IWindowManager>().ShowWindow(MainWindowViewModel.Instance);
        }

        protected override void Configure()
        {
            base.Configure();
            SetupCaliburnShortcutMessage();
        }

        private static void SetupCaliburnShortcutMessage()
        {
            var currentParser = Parser.CreateTrigger;
            Parser.CreateTrigger = (target, triggerText) =>
            {
                if (ShortcutParser.CanParse(triggerText))
                {
                    return ShortcutParser.CreateTrigger(triggerText);
                }

                return currentParser(target, triggerText);
            };
        }
    }
}