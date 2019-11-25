using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Builder.IBuilder;

namespace Web.Builder.ConcreteBuilder
{
    public class DesktopBuilder : ISystemBuilder
    {
        ComputerSystem Desktop = new ComputerSystem();
        public ISystemBuilder AddDrive(string hddSize)
        {
            Desktop.HDDSize = hddSize;
            return this;
        }

        public ISystemBuilder AddKeyboard(string type)
        {
            Desktop.Keyboard = type;
            return this;
        }

        public ISystemBuilder AddMemory(string memory)
        {
            Desktop.RAM = memory;
            return this;
        }

        public ISystemBuilder AddMouse(string type)
        {
            Desktop.Mouse= type;
            return this;
        }

        public ISystemBuilder AddTouchScreen(string enabled)
        {
            return this;
        }

        public ComputerSystem GetSystem()
        {
            return Desktop;
        }
    }
}