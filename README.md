# EmployerPortal
EmployerPortalWebApp  and EmployerService

EmployerPortalApp - Web Layer - Provides login register functionality via asp.net identity. Once authenticated User lands on Portal with grid of Employers(View) populated via service call. Selecting a record, populates another grid of employees(Partial View). 

EmployerPortal.Service - Controller calls this layer and this layer communicates with external service and provides the results. Any business logic before displaying to client can be implemented here.

EmployerPortal.Common - This provides common models,extensions etc

EmployerPortal.Test- Contains unit test for the project
