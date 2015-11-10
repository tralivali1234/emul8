//
// Copyright (c) Antmicro
// Copyright (c) Realtime Embedded
//
// This file is part of the Emul8 project.
// Full license details are defined in the 'LICENSE' file.
//
﻿using Antmicro.OptionsParser;

namespace Emul8Launcher
{
    public class Options : IValidatedOptions
    {
        [Name('d', "debug"), Description("Use non-optimized, debugabble version.")]
        public bool Debug { get; set; }
        
        [Description("Do not output errors on console.")]
        public bool Quiet { get; set; }
        
        [Name('p', "port"), Description("Listen for external debugger."), DefaultValue(-1)]
        public int DebuggerSocketPort { get; set; }
        
        [Name("help-cli"), Description("Show help for CLI.")]
        public bool HelpCLI { get; set; }
        
        [Name("root-path"), Description("Search for binaries in this directory."), DefaultValue(".")]
        public string RootPath { get; set; }
        
        public bool Validate(out string error)
        {
            if(!Debug && DebuggerSocketPort != -1)
            {
                error = "Debugger is not available in 'Release' mode";
                return false;
            }
            
            error = null;
            return true;
        }
    }
}
