namespace back_Fluxi.Models
{
    public class Faq
    {
        private int id;
        private string text;

        public Faq()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
    }
}
