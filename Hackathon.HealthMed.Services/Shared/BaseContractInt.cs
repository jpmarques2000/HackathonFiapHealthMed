using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Shared
{
    public abstract class BaseContractInt : Notifiable<Notification>
    {

        protected abstract void Validate(int entity);
    }
}
