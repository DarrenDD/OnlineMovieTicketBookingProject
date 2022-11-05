namespace OnlineMovieTicketBookingProject.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Movie_Name { get; set; }
        public string Movie_Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string MoviePicture { get; set; }
        public virtual ICollection<BookingTable> Bookings { get; set; }
    }
}
