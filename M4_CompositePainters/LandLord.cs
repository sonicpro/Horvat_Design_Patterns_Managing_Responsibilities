namespace M4_CompositePainters
{
    public class LandLord
    {
        private int totalHouses;

        // The dedicated painter
        private Painter painter;

        public LandLord(int totalHouses)
        {
            this.totalHouses = totalHouses;
            this.painter = new Painter(4);
        }

        public void MaintainHouses()
        {
            painter.Paint(totalHouses);
        }
    }
}
