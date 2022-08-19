using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Alunos
        public Aluno[] GetAllAlunos(bool includeProfessor = false);
        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        public Aluno GetAlunoById(int professorId, bool includeProfessor = false);
        public Aluno GetAlunoByName(string name, bool includeProfessor = false);

        // Professores
        public Professor[] GetAllProfessores(bool includeAluno = false);
        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false);
        public Professor GetProfessorById(int alunoId, bool includeAluno = false);
        public Professor GetProfessorByName(string name, bool includeAluno = false);
    }
}
