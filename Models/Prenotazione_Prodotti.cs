public class Prenotazione_Prodotti
{
    public int? Prenotazione_ProdottiId { get; set; }
    public int? Quantita { get; set; }
    public int? ProdottiId { get; set; }
    public Prodotti? Prodotti { get; set; }
    public int? PrenotazioneId { get; set; }
    public Prenotazione? Prenotazione { get; set; }
}