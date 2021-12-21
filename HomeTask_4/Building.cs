using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4
{
    class Building
    {
        private static int _defBuildingNumber; 
        private int _buildingNumber; // Номер здания.
        private int _height; // Высота.
        private int _numberOfStoreys;  // Этажность.
        private int _numberOfApartments;  // Кол-во квартир.
        private int _numberOfEntrances; // Кол-во подъездов.

        public Building()
        {
            _buildingNumber = GetNewDefBuildingNumber();  
        }

        #region // Методы установки значений.
        public void SetBuildingNumber(int number)
        {
            _buildingNumber = number; 
        }
        public void SetBuildingHeight(int height)
        {
            _height = height;
        }
        public void SetNumberOfStoreys(int numberOfStoryes)
        {
            _numberOfStoreys = numberOfStoryes;
        }
        public void SetNumberOfApartments(int numberOfApartments)
        {
            _numberOfApartments = numberOfApartments;
        }
        public void SetNumberOfEntrances(int numberOfEntrances)
        {
            _numberOfEntrances = numberOfEntrances;
        }
        #endregion

        #region // Методы считывания значений.
        public int GetBuildingNumber()
        {
            return _buildingNumber;
        }
        public int GetBuildingHeight()
        {
            return _height;
        }
        public int GetNumberOfStoreys()
        {
            return _numberOfStoreys;
        }
        public int GetNumberOfApartments()
        {
            return _numberOfApartments;
        }
        public int GetNumberOfEntrances()
        {
            return _numberOfEntrances;
        }
        #endregion

        #region // Методы подсчета значений.
        private int GetNewDefBuildingNumber()
        {
            return ++_defBuildingNumber; 
        }
        public double GetFloorHeight() // Получение высоты одного этажа здания.
        {
            return _height / _numberOfStoreys; 
        }
        public int GetNumberOfApartmentsInEntance() // Получение кол-во квартир в подъезде.
        {
            return _numberOfApartments / _numberOfEntrances; 
        }
        public int GetNumberOfApartmentsOnFloor() // Получение кол-ва квартир на этаже.
        {
            return GetNumberOfApartmentsInEntance() / _numberOfStoreys;
        }
        #endregion 
    }
}
