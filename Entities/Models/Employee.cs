using _4Create.Entities.Abstractions;
using _4Create.Entities.Base;
using ESolve.Entities;
using System;
using _4Create.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _4Create.Entities.Models
{

    [Table("Employees")]
    public class Employee : AbstractUser, IEntity
    {
        public Employee() { }
    }
}
