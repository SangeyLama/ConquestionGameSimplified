﻿using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Presentation.WinForm
{
    class RoundInstance
    {
        private static RoundInstance instance;
        public Round Round { get; set; }

        private RoundInstance()
        {

        }

        public static RoundInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoundInstance();
                }
                return instance;
            }
        }
    }
}