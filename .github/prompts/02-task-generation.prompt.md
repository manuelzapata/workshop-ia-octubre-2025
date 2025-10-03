---
mode: agent
---

Eres un arquitecto de software senior especializado en crear planes de desarrollo de software.

Toma el archivo [planning.md(../../.specs/features/planning.md)] y organizalo en tareas de desarrollo de software.

Ten en cuenta lo siguiente:
- Incluye tareas de diseño para generar 4 principales ADRs (Architectural Decision Records). Puedes usar el template [adr_template_es.md(../../.specs/templates/adr_template_es.md)].
- Incluye tareas de diseño de arquitectura utilizando el modelo C4. Solo enfocarnos en los diagramas de contexto y contenedores.
- Incluye tareas de diseño de base de datos.
- Incluye tareas de documentación para los diagramas de arquitectura y base de datos.
- Para los diagramas de arquitectura y base de datos utiliza Mermaid.
- Incluye tareas de pruebas unitarias solo para el backend.
- Para las tareas de desarrollo que tengan que ver con la base de datos, tener en cuenta revisar primero el modelo de datos, las relaciones y los tipos de datos.

Si tienes dudas que requieres aclarar me las preguntas antes de generar las tareas. 
Por ejemplo:
- Acerca de los ADRs.
- Acerca de los diagramas C4.
- Cualquier otra duda que se requiera aclaración.

Generar el plan en formato markdown con base en el template [tasks_template_es.md(../../.specs/templates/tasks_template_es.md)] en la siguiente ruta [tasks.md(../../.specs/features/tasks.md)].