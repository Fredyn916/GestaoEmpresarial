﻿using Core.Interface.Service.Generic;
using Entidades;

namespace Core.Interface.Service;

public interface ICargoService : IGenericService<Cargo>
{
    Task Initialize();
}