## ESTA SOLUCION CONTIENE SOLO LA API Y EL UNIT TESTING ##
Verion se .NET = 8.0 (Se recomienda Visual Studio 2022 o JetBrains Rider)

El proyecto API contiene (como base principal):
  * connecctionString: tiene que ser una cadena conformada 1 por ip de servidor 2 base de datos 3 usuario (preferible root) 4 contraseña (en blanco si no tiene contraseña el usuario) 
  quedando en una cadena asi: 'Server=localhost;Database=nombreTabla;User Id=usuario;Password=contraseña;Charset=utf8mb4;'

Para ejecutar las pruebas unitarias solo hace falta marcar en la pestaña "Prueba" (Visual studio 2022) y darle a "Ejecutar todas las pruebas"
