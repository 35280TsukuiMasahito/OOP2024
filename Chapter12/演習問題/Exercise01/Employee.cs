using System;
using System.Text.Json.Serialization;

public class Employee {
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime HireDate { get; set; }
}