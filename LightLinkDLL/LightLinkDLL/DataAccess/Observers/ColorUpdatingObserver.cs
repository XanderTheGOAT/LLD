using LightLink.Extensions;
using LightLink.Models.Colors;
using LightLink.Services;
using LightLinkModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightLinkDLL.DataAccess
{
    public class ColorUpdatingObserver : IObserver<Profile>
    {
        private static readonly ILogger defaultLogger;
        static ColorUpdatingObserver()
        {
            defaultLogger = new ConsoleLogger();
        }
        public IColorService CurrentService { get; }
        public ILogger Log { get; }

        public ColorUpdatingObserver(IColorService colorService): this(colorService, defaultLogger)
        {
        }
        public ColorUpdatingObserver(IColorService currentService, ILogger log)
        {
            CurrentService = currentService;
            Log = log;
        }

        public void OnCompleted()
        {
            //TODO: do something when done called.
        }

        public void OnError(Exception error)
        {
            Log.LogError(error);
        }

        public void OnNext(Profile value)
        {
            Log.Log("Profile Found: ");
            Log.Log(value);
            if(value.Configurations.TryGetValue("keyboard", out var keyboardValue))
            {
                CurrentService.ChangeKeyboardColor(new CompanyColor(keyboardValue));
            }
            if (value.Configurations.TryGetValue("mouse", out var mouseValue))
            {
                CurrentService.ChangeMouseColor(new CompanyColor(mouseValue));
            }
            if (value.Configurations.TryGetValue("headset", out var headsetValue))
            {
                CurrentService.ChangeHeadsetColor(new CompanyColor(headsetValue));
            }
            if (value.Configurations.TryGetValue("headsetStand", out var headStandValue))
            {
                CurrentService.ChangeHeadsetStandColor(new CompanyColor(headStandValue));
            }
            if (value.Configurations.TryGetValue("mouseMat", out var mouseMatValue))
            {
                CurrentService.ChangeMousematColor(new CompanyColor(mouseMatValue));
            }
        }
    }
}
