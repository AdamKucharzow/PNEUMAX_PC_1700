using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL.PMEUMAX_PC_1700.Driver.API
{
    public class Pneumax_PC_1700
    {
        private readonly PneumaxModel model;
        private ICommandSender commandSender;

        public Pneumax_PC_1700(PneumaxModel model)
        {
            this.model = model;
        }

        public Pneumax_PC_1700(PneumaxModel pneumaxModel, ICommandSender commandSender)
        {
            this.model = pneumaxModel;
            this.commandSender = commandSender;
        }

        public ICommandSender CommandSender { set => this.commandSender = value; }

        public PneumaxModel Model => model;

        public bool SetPressure(int pressureToSet)
        {
            if (this.commandSender == null)
                throw new ArgumentNullException(nameof(pressureToSet));

            this.commandSender.SendCommand
        }
    }
}
