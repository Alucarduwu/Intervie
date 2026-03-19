# Panacea Media Player

Este es un reproductor multimedia sencillo hecho en C# con .NET Framework 4.8 y WPF.

## Cómo usarlo

1. Abre el archivo `PanaceaMediaPlayer.sln` en **Visual Studio**.
2. El proyecto usa **Newtonsoft.Json**, así que asegúrate de restaurar los paquetes de NuGet (Visual Studio suele hacerlo solo al compilar).
3. Pulsa **F5** o "Iniciar" para correr la app.

## Estructura

- **Models**: Contiene la definición de los datos (`MediaItem.cs`).
- **Services**: Maneja la conexión con la API (`ApiService.cs`).
- **ViewModels**: Tiene la lógica del reproductor y el manejo de eventos (`MainViewModel.cs`).
- **Views**: El diseño visual en XAML (`MainWindow.xaml`).

## Requisitos
- .NET Framework 4.8
- Visual Studio 2019 o superior
