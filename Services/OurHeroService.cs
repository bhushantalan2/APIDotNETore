using DotNetWebAPI.Model;

namespace DotNetWebAPI.Services
{
    public class OurHeroService:IOurHeroService
    {
        private readonly List<OurHero> _ourHeroesList;

        public OurHeroService() {
            _ourHeroesList = new List<OurHero>(){
                new OurHero(){
                    Id = 1,
                    FirstName = "Test",
                    LastName = "",
                    IsActive = true,
                }
            };
        }
        public List<OurHero> GetAllHeros(bool? isAtive)
        {
            return isAtive==null? _ourHeroesList: _ourHeroesList.Where(hero => hero.IsActive).ToList();
        }
        public OurHero? GetHeroById(int id) { 
            return _ourHeroesList.FirstOrDefault(hero => hero.Id==id);
        }
        public OurHero AddOurHero(AddUpdateOurHero obj) {
            var addHero = new OurHero()
            {
                Id = _ourHeroesList.Max(hero => hero.Id) + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                IsActive = obj.isActive
            };
            return addHero;
        }
        public OurHero? UpdateOurHero(int id, AddUpdateOurHero obj) { 
            var ourHeroIndex = _ourHeroesList.FindIndex(index => index.Id==id);
            if (ourHeroIndex > 0)
            {
                var hero = _ourHeroesList[ourHeroIndex];
                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.IsActive = obj.isActive;
                _ourHeroesList[ourHeroIndex] = hero;
                return hero;
            }
            else
            {
                return null;
            }
           
        }
        public bool DeleteHerosByID(int id) { 

            var ourHerosIndex = _ourHeroesList.FindIndex(_index => _index.Id==id);
            if (ourHerosIndex>=0) {
            _ourHeroesList.RemoveAt(ourHerosIndex);
            }
            return ourHerosIndex >= 0;
        }
    }
}
