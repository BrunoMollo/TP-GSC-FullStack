# TP-GSC-FullStack
Trabajo practico integrador realizado para el curso de formación de desarrollo FullStack realizado en el Grupo San Cristóbal.

La idea es desarrollar un sistema de préstamos de "cosas". A quien no le sucedió que le prestó algo a un amigo o amiga y más tarde se olvido a quien se lo prestó y cuando. La idea de este sistema es ayudarnos a recordar a quien y cuando se lo prestamos.


## Modelo del dominio
![Alt text](https://github.com/BrunoMollo/TP-GSC-FullStack/blob/main/Domain%20Things%20Loans.png?raw=true "Title")


## Requisitos

### Para el final del curso, como mínimo, cada alumno deberá entregar:
* Alta de Categorías por defecto en una aplicación de consola o WebAPI. La aplicación solo debe agregar las categorías si las mismas no existen todavia.
* ABM de Personas con Web API
* ABM de Cosas en una aplicación MVC
* Marcar el préstamo como devuelto con una llamada de gRPC.
* Proyecto de UnitTests que pruebe un controller (puede ser del proyecto de MVC o del proyecto de WebAPI).
* Del lado del frontend (Angular), armar una página de Login, que me permita acceder al sistema (Llamando a las APIs de Autenticacion). Una vez ingresado vamos a poder acceder a un ABM de personas la cual debe estar segurizada usando JWT.

### Requisitos Tecnicos
* App en NetCore 6
* Uso de EntityFramework Core en toda la solución
* La solución debe ser entregada en Github y compartida con el del profesor.

### Opcional
* Implementar Logging en archivos
* Implementar Automapper
* Agregar validaciones Back End que crean pertinentes
* Agregar Swagger
* Agregar autenticacion con Swagger
* Utilizar metodos asincronicos en controllers y repositorios
* Otros conceptos aprendidos en el curso que crean pertinentes

## Agradecimentos
Gracias a los dos profesores que tuvimos durante el curso. Tanto Lucho en el Front como Marcos en el Back demostraron un gran interes por el aprendizaje de los alumnos. Explicaron los temas de una manera exepcional, nos incentivaron a participar y generaron un ambiente comodo para preguntar. Aprendi mucho en este curso y se lo debo a ellos.  

## Aclaracion
Este trabajo fue pensado para implemetar todas las practicas dictadas en el curso. Por lo cual se puede ver un uso de tecnicas y tecnologias que no seria el optimo (por ejemplo: tener el Frontend en Angular y en MVC, o el uso de gRCP para llamar a un endpoint desde el frontend).



