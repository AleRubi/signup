using Microsoft.AspNetCore.SignalR;

public class Prenotazione
{
    public int? PrenotazioneId { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public string? Email { get; set; }
    public DateOnly dataNascita { get; set; }
    public string? sesso { get; set; }
    public string? ruolo { get; set; }
}