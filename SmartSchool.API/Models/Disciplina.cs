namespace SmartSchool.API.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

        public Disciplina()
        {
        }

        public Disciplina(int id, string name, int professorId)
        {
            Id = id;
            Name = name;
            ProfessorId = professorId;
        }
    }
}
