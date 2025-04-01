# Proyecto ACME Management Library
## *Antonio Marín Carmona - 02/04/2025*

# Índice

- [Introducción](#introducción)
- [Requisitos](#requisitos)
- [Lo que hicimos](#lo-que-hicimos)
- [Lo que nos hubiera gustado hacer pero no hicimos](#lo-que-nos-hubiera-gustado-hacer-pero-no-hicimos)
- [Lo que hicimos, pero se podría mejorar o necesitaría revisión si el proyecto avanza](#lo-que-hicimos-pero-se-podría-mejorar-o-necesitaría-revisión-si-el-proyecto-avanza)
- [Librerías de terceros utilizadas](#librerías-de-terceros-utilizadas)
- [Tiempo invertido y aprendizaje](#tiempo-invertido-y-aprendizaje)

## Introducción
Este proyecto tiene como **objetivo** proporcionar una biblioteca para la gestión de cursos y estudiantes. Se ha diseñado con principios de modularidad y escalabilidad para facilitar futuras mejoras.  
Ha sido desarrollado en C# con .NETCore 8 y XUnit.net.  
 
Hemos utilizado un **modelo de dominio rico**, utilizando **abstracciones** de cara a una **posible futura ampliación** de la librería, la creación de una API o el uso de una base de datos.  
También hemos creado un **proyecto de pruebas unitarias** para comprobar el correcto funcionamiento.

## Requisitos

El programa debe realizar las siguientes tareas:
- **Dar de alta a un alumno** especificando su nombre y edad (sólo pueden matricularse mayores de edad).
- **Dar de alta un curso** con un nombre, cuota de inscripción, fecha de inicio y fecha de finalización.
- Permitir **que un alumno se matricule en un curso** tras pagar la matrícula, si procede, a través de una pasarela de pago.
- **Proporcionar una lista de cursos** y sus alumnos matriculados dentro de un intervalo de fechas especificado.

Nos solicitan: 
- Una implementación en C# con una **librería de clases que incluya código de producción** y un **proyecto de pruebas utilizando xUnit.net**
- **Crear las abstracciones adecuadas** y dejar el código en un estado que permita futuras mejoras si es necesario.
- Crear un **modelo de dominio rico**.

## Lo que hicimos
- ### Implementamos la gestión de cursos y estudiantes. Creando la siguiente estructura:  
    - **Entities**: Modelos centrales del dominio. Contienen los atributos y la ógica y reglas inherentes de cada entidad.  
        - **Course.cs:** Creación de cursos y gestión de inscripciones.
        - **Student.cs:** Creación de estudiantes.  
        
    - **Infrastructure**: Implementaciones que que comunican el dominio con sistemas externos sin contaminar la lógica de dominio y permitiendo que éste permanezca intacto de que se produzcan cambios externos (como la base de datos o el sistema de pago.)
        - **CourseRepository.cs**: Implementa la forma de almacenar, recuperar o actualizar objetos Course en una base de datos u otro mecanismo de persistencia.
        - **PaymentService.cs**: Encapsula la comunicación con un posible sistema de pago.  

    - **Interfaces**: Se definen labstracciones que deben cumplir las implementaciones de la capa de infraestructura.
        - **ICourseRepository.cs**: Métodos necesarios para la manipulación de cursos
        - **IPaymentService.cs**: Operaciones básicas para el procesamiento de pagos  

    - **Services**: Esta capa se encarga de la coordinación o orquestación de la lógica de negocio que involucra múltiples elementos o que trasciende a una sola entidad.
        - **CourseService.cs**: Contieneógica de negocio relacionada con la gestión de cursos. Actúa como intermediaria entre el dominio y la infraestructura.

    - **Utils**: Contienen funciones y métodos comunes que se utilizan en distintas partes del proyecto, ayudando a evitar duplicaciones
        - **DateUtils.cs**: Ofrece métodos para trabajar con fechas, como formateo, cálculos de intervalos o validaciones.
        - **Validators.cs**: Proporciona funciones genéricas para la validación de datos.  
          

- ### Se incorporaron pruebas unitarias utilizando **xUnit** y **Moq**.
    - **Application**:
        - **CourseServiceTests**: Verifica la recuperación de cursos con estudiantes inscritos
    - **Domain**: 
        - **CourseTests.cs**: Verifica reglas de negocio como la creación de curos, inscripción de estudiantes en cursos, validación de fechas y pagos.
        - **StudentTest.cs**:  Valida reglas a la hora de añadir estudiantes: Nombres válidos y edad mínima al crear un estudiante.
    - **Infrastructure**: 
        - **CourseRepositoryTest.cs**: Verifica la recuperación de curos.
    - **Mocks**: 
        - **FakePaymentService.cs**: Mockeamos el servicio de pago para hacer los tests.

## Lo que nos hubiera gustado hacer pero no hicimos
- Crear una base de datos para gestionar los datos de nuestra librería.
- Publicar como API la librería para que pueda ser consumida.
- Creación de nuevas entidades, por ejemplo, los profesores que impartirán el curso.


## Lo que hicimos, pero se podría mejorar o necesitaría revisión si el proyecto avanza
- Mejorar la lógica de inscripción con una validación más avanzada, añadiendo los datos en las distintas entidades que serán necesarios en un futuro. Por ejemplo, más información de los estudiantes o más detalles del curso.
- Conocer en detalle los futuros evolutivos del proyecto para haberme anticipado. Por ejemplo, varios tipos de cursos para poder añadir herencias más interfaces.
- Planteé crear una interfaz para student, pero al ser la creación de estudiantes la única tarea de la entidad Student, he decidido dejarlo sólo como entidad. 


## Librerías de terceros utilizadas
Las siguientes librerías fueron empleadas en el proyecto:
- **Moq**: Se usó para simular dependencias en pruebas unitarias en CourseServiceTests.cs.
- **xUnit**: Framework de pruebas utilizado para validar el comportamiento de los métodos.

## Tiempo invertido y aprendizaje
Este proyecto ha requerido un esfuerzo de aproximadamente 12 horas. Gran parte del tiempo se invirtió en plantear la estructura del proyecto y en organizar las clases para poder implementar un modelo de dominio rico de la mejor forma posible. 
  
Durante este tiempo, he investigado principalmente los siguientes temas:
- Creación de dominio rico y la forma óptima de estructurar el proyecto y crear las abstracciones para este modelo. Aunque he visto anteriormente este modelo, nunca había creado uno de cero.
- Buenas prácticas en pruebas unitarias con XUnit. Intentando encontrar el equilibrio, de forma que no quede nada sin probar y no existan redundancias o pruebas duplicadas.
- Manejo de dependencias con Moq.
