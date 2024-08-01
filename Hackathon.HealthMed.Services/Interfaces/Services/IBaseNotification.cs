﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Interfaces.Services
{
    public interface IBaseNotification
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        bool IsValid { get; }
    }
}
