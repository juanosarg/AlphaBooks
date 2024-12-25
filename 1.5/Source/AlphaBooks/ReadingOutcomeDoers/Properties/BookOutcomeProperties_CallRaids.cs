﻿using RimWorld;
using System;
using System.Collections.Generic;

namespace AlphaBooks
{
    public class BookOutcomeProperties_CallRaids : BookOutcomeProperties
    {
        public List<float> lengthForQualities;


        public override Type DoerClass => typeof(ReadingOutcomeDoer_CallRaids);
    }
}