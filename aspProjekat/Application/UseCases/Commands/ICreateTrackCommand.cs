﻿using aspProjekat.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.Commands
{
    public interface ICreateTrackCommand : ICommand<CreateTrackDTO>
    {
    }
}
