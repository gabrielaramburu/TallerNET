using DemoPartialPages.Models;

namespace DemoPartialPages.Repositories;

/// <summary>
/// Implementación en memoria del repositorio de vehículos utilizando una estructura de datos tipo Mapa (Dictionary).
/// </summary>
public class VehiculoEnMemoriaRepository : IVehiculoRepository
{
    private readonly Dictionary<int, Vehiculo> _vehiculos = new();

    public VehiculoEnMemoriaRepository()
    {
        CargarDatosDePrueba();
    }

    public IEnumerable<Vehiculo> ObtenerTodos()
    {
        return _vehiculos.Values.OrderBy(v => v.Id);
    }

    public Vehiculo? ObtenerPorId(int id)
    {
        _vehiculos.TryGetValue(id, out var vehiculo);
        return vehiculo;
    }

    /// <summary>
    /// Carga inicial de datos de prueba variados para permitir scroll y pruebas pedagógicas.
    /// </summary>
    private void CargarDatosDePrueba()
    {
        var lista = new List<Vehiculo>
        {
            // 1. Automóviles
            new Automovil
            {
                Id = 1,
                Marca = "Toyota",
                Modelo = "Corolla SEG",
                Anio = 2023,
                Patente = "AF 123 CD",
                Precio = 24500000m,
                Color = "Blanco Perlado",
                CantidadPuertas = 4,
                Combustible = TipoCombustible.Hibrido,
                TieneCajaAutomatica = true,
                TieneAireAcondicionado = true
            },
            new Automovil
            {
                Id = 2,
                Marca = "Volkswagen",
                Modelo = "Polo GTS",
                Anio = 2022,
                Patente = "AE 987 WX",
                Precio = 19800000m,
                Color = "Rojo Tornado",
                CantidadPuertas = 5,
                Combustible = TipoCombustible.Nafta,
                TieneCajaAutomatica = true,
                TieneAireAcondicionado = true
            },
            new Automovil
            {
                Id = 3,
                Marca = "Peugeot",
                Modelo = "208 Feline",
                Anio = 2023,
                Patente = "AF 445 JJ",
                Precio = 18200000m,
                Color = "Gris Artense",
                CantidadPuertas = 5,
                Combustible = TipoCombustible.Nafta,
                TieneCajaAutomatica = true,
                TieneAireAcondicionado = true
            },
            new Automovil
            {
                Id = 4,
                Marca = "Chevrolet",
                Modelo = "Cruze Premier",
                Anio = 2021,
                Patente = "AE 321 LL",
                Precio = 21000000m,
                Color = "Negro Ebony",
                CantidadPuertas = 4,
                Combustible = TipoCombustible.Nafta,
                TieneCajaAutomatica = true,
                TieneAireAcondicionado = true
            },
            new Automovil
            {
                Id = 5,
                Marca = "Nissan",
                Modelo = "Leaf Tekna",
                Anio = 2024,
                Patente = "AG 102 EE",
                Precio = 34000000m,
                Color = "Azul Eléctrico",
                CantidadPuertas = 5,
                Combustible = TipoCombustible.Electrico,
                TieneCajaAutomatica = true,
                TieneAireAcondicionado = true
            },

            // 2. Utilitarios
            new Utilitario
            {
                Id = 6,
                Marca = "Renault",
                Modelo = "Kangoo Express",
                Anio = 2021,
                Patente = "AD 456 EF",
                Precio = 16200000m,
                Color = "Gris Plata",
                CapacidadCargaKg = 750,
                VolumenCargaM3 = 3.9,
                TienePuertaLateral = true,
                EsFurgonCerrado = true
            },
            new Utilitario
            {
                Id = 7,
                Marca = "Toyota",
                Modelo = "Hilux DX 4x2",
                Anio = 2024,
                Patente = "AG 321 JK",
                Precio = 31000000m,
                Color = "Blanco",
                CapacidadCargaKg = 1050,
                VolumenCargaM3 = 2.4,
                TienePuertaLateral = false,
                EsFurgonCerrado = false
            },
            new Utilitario
            {
                Id = 8,
                Marca = "Ford",
                Modelo = "Transit Van Mediana",
                Anio = 2022,
                Patente = "AE 512 MN",
                Precio = 42000000m,
                Color = "Blanco Oxford",
                CapacidadCargaKg = 1420,
                VolumenCargaM3 = 10.7,
                TienePuertaLateral = true,
                EsFurgonCerrado = true
            },
            new Utilitario
            {
                Id = 9,
                Marca = "Fiat",
                Modelo = "Fiorino Endurance",
                Anio = 2023,
                Patente = "AF 890 PP",
                Precio = 14500000m,
                Color = "Blanco Banchisa",
                CapacidadCargaKg = 650,
                VolumenCargaM3 = 3.1,
                TienePuertaLateral = false,
                EsFurgonCerrado = true
            },
            new Utilitario
            {
                Id = 10,
                Marca = "Volkswagen",
                Modelo = "Amarok V6 Extreme",
                Anio = 2024,
                Patente = "AG 774 QQ",
                Precio = 48000000m,
                Color = "Azul Atlántico",
                CapacidadCargaKg = 1100,
                VolumenCargaM3 = 2.5,
                TienePuertaLateral = false,
                EsFurgonCerrado = false
            },

            // 3. Camiones
            new Camion
            {
                Id = 11,
                Marca = "Mercedes-Benz",
                Modelo = "Actros 2651",
                Anio = 2022,
                Patente = "AE 654 GH",
                Precio = 95000000m,
                Color = "Azul Noche",
                CantidadEjes = 3,
                CapacidadToneladas = 45.0,
                TieneAcoplado = true,
                TipoCabina = "Dormitorio Megaspace"
            },
            new Camion
            {
                Id = 12,
                Marca = "Scania",
                Modelo = "R500 Highline",
                Anio = 2023,
                Patente = "AF 789 OP",
                Precio = 11000000m,
                Color = "Amarillo Canario",
                CantidadEjes = 4,
                CapacidadToneladas = 60.0,
                TieneAcoplado = true,
                TipoCabina = "Dormitorio Highline"
            },
            new Camion
            {
                Id = 13,
                Marca = "Iveco",
                Modelo = "Stralis Hi-Way",
                Anio = 2020,
                Patente = "AD 220 ZZ",
                Precio = 78000000m,
                Color = "Blanco Marfil",
                CantidadEjes = 3,
                CapacidadToneladas = 40.0,
                TieneAcoplado = true,
                TipoCabina = "Dormitorio"
            },
            new Camion
            {
                Id = 14,
                Marca = "Volvo",
                Modelo = "FH 540 Globetrotter",
                Anio = 2024,
                Patente = "AG 950 YY",
                Precio = 125000000m,
                Color = "Plata Metalizado",
                CantidadEjes = 4,
                CapacidadToneladas = 65.0,
                TieneAcoplado = true,
                TipoCabina = "Globetrotter XL"
            }
        };

        foreach (var vehiculo in lista)
        {
            _vehiculos[vehiculo.Id] = vehiculo;
        }
    }
}
