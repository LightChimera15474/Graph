namespace Graph
{
    class Vertex
    {
        public int ID { get; }
        public int Level { get; set; }

        public Vertex(int id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
