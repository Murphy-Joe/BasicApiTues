using System.ComponentModel.DataAnnotations;

namespace BasicApi.Data;

public class Agent
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }

    public DateTime Added { get; set; }
    public bool Retired { get; set; }

    public string? State { get; set; }

}