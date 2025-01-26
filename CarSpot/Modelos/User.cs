public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
         public bool IsBlocked { get; set; }
         public DateTime? BlockedUntil { get; set; }
    }