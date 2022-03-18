using System.ComponentModel.DataAnnotations;
using Minimal.Enums;

namespace Minimal.Models;

public class Truck
{
    public Guid Id { get; private set; }

    public DateTime ManufacturingDate { get; set; }

    public EModel Model { get; set; }

    public DateTime ModelDate { get; set; }
}
