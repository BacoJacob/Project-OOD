﻿using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class SayCommand : Command
    {
        public SayCommand() : base()
        {
            this.Name = "say";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.Say(this.SecondWord);
            }
            else
            {
                player.OutputMessage("\nSay what?");
            }
            return false;
        }

    }
}
