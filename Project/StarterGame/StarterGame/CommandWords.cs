﻿using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class CommandWords
    {
        private Dictionary<string, Command> commands;
        private static Command[] commandArray = { new GoCommand(), new BackCommand(), new QuitCommand() };
        public CommandWords() : this(commandArray) {}

        // Designated Constructor
        public CommandWords(Command[] commandList)
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in commandList)
            {
                commands[command.Name] = command;
            }
            Command help = new HelpCommand(this);
            commands[help.Name] = help;
            Command log = new LogCommand(this);
            commands[log.Name] = log;
            Command restart = new RestartCommand(this);
            commands[restart.Name] = restart;
        }

        public Command Get(string word)
        {
            Command command = null;
            commands.TryGetValue(word, out command);
            return command;
        }

        public string Description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            foreach (string commandName in keys)
            {
                commandNames += commandName + " ";
            }
            return commandNames;
        }

        public String Log()
        {
            Game _game = new Game();
            List<string> logList = _game.GetLog();
            string loggedCommands = "";
            foreach(string loggedCommand in logList)
            {
                loggedCommands = loggedCommand + "\n";
            }
            return loggedCommands;
        }
    }
}
