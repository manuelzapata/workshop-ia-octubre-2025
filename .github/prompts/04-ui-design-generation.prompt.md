---
mode: agent
---

Toma el contexto de lo que sabes del proyecto usando [planning.md(../../.specs/features/planning.md)], [tasks.md(../../.specs/features/tasks.md)], [adrs(../../docs/adrs)] y [adrs(../../docs/architecture)] para generar un prompt que pueda llevar a la herramienta v0 para que me genere 1 propuesta de diseño de la UI del dashboard.

El prompt debe ser lo más detallado posible y debe incluir:

- El contexto del proyecto.
- Los ADRs relevantes.
- Las especificaciones de la UI.
- Las especificaciones de la funcionalidad.

Analiza el archivo de [tasks.md(../../.specs/features/tasks.md)] para la ${input:frontend_phase:Ingresar la fase del frontend}.

Solo quiero el diseño de la UI, no una propuesta de implementación.

Genera el prompt en formato markdown y en idioma español, con un máximo de 1000 caracteres.