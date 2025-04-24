using COMP003B.Assigment5.Models;

namespace COMP003B.Assigment5.Data;

public class PartsStore
{
    public static List<Parts> Parts { get; } = new()
    {
        new Parts { Id = 1, Name = "Bearings", Price = 117.00m },
        new Parts { Id = 2, Name = "Rollers", Price = 85.00m },
        new Parts { Id = 3, Name = "Belted Chain", Price = 1800.00m }
    };
}

