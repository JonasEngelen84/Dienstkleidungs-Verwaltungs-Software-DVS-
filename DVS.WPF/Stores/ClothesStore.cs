﻿using DVS.Domain.Commands.Clothes;
using DVS.Domain.Models;
using DVS.Domain.Queries;

namespace DVS.WPF.Stores
{
    public class ClothesStore(IGetAllClothesQuery getAllClothesQuery,
                              ICreateClothesCommand CreateClothesCommand,
                              IUpdateClothesCommand UpdateClothesCommand,
                              IDeleteClothesCommand DeleteClothesCommand)
    {
        private readonly IGetAllClothesQuery _getAllClothesQuery = getAllClothesQuery;
        private readonly ICreateClothesCommand _createClothesCommand = CreateClothesCommand;
        private readonly IUpdateClothesCommand _updateClothesCommand = UpdateClothesCommand;
        private readonly IDeleteClothesCommand _deleteClothesCommand = DeleteClothesCommand;

        private readonly List<Clothes> _clothes = [];
        public IEnumerable<Clothes> Clothes => _clothes;

        public event Action ClothesLoaded;
        public event Action<Clothes> ClothesAdded;
        public event Action<Clothes> ClothesUpdated;
        public event Action<Guid> ClothesDeleted;

        public async Task Load()
        {
            try
            {
                //IEnumerable<Clothes> clothes = await _getAllClothesQuery.Execute();

                _clothes.Clear();

                //if (clothes != null)
                //{
                //    _clothes.AddRange(clothes);
                //}

                ClothesLoaded?.Invoke();
            }
            catch (Exception ex)
            {
                //TODO: Fehlerbehandlung beim laden der aus DB
                Console.WriteLine($"Fehler beim Laden der Clothes: {ex.Message}");
            }
        }

        public async Task Add(Clothes clothes)
        {
            //await _createClothesCommand.Execute(clothes);
            _clothes.Add(clothes);
            ClothesAdded.Invoke(clothes);
        }

        public async Task Update(Clothes clothes)
        {
            //await _updateClothesCommand.Execute(clothes);

            int index = _clothes.FindIndex(y => y.GuidID == clothes.GuidID);

            if (index != -1)
            {
                _clothes[index] = clothes;
            }
            else
            {
                _clothes.Add(clothes);
            }

            ClothesUpdated.Invoke(clothes);
        }

        public async Task Delete(Guid guidID)
        {
            //await _deleteClothesCommand.Execute(guidID);

            _clothes.RemoveAll(y => y.GuidID == guidID);
            ClothesDeleted?.Invoke(guidID);
        }
        
        public async Task DragNDropUpdate(Clothes clothes)
        {           
            int index = _clothes.FindIndex(y => y.GuidID == clothes.GuidID);

            if (index != -1)
            {
                _clothes[index] = clothes;
            }
            else
            {
                _clothes.Add(clothes);
            }

            ClothesUpdated.Invoke(clothes);
        }
    }
}
