using SQLite;
using People.Models;
//using Android.Health.Connect;

namespace People;

public class PersonRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    private SQLiteAsyncConnection salmeida_conexion;
    
    private async Task Init()
    {
        if (salmeida_conexion != null){ return; }
        salmeida_conexion = new SQLiteAsyncConnection(_dbPath);
        await salmeida_conexion.CreateTableAsync<Person>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    public async Task AddNewPerson(string name)
    {            
        int result = 0;
        try
        {
            Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            // TODO: Insert the new person into the database
            result = await salmeida_conexion.InsertAsync(new Person { Name = name });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }

    public async Task<List<Person>> GetAllPeople()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            await Init();
            return await salmeida_conexion.Table<Person>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Person>();
    }
    
    public async Task DeletePerson(Person persona)
    {
        await Init();
        await salmeida_conexion.DeleteAsync(persona);
    }
}
