## Rinzo

[![CodeQL](https://github.com/nixhantb/Rinzo/actions/workflows/codeql.yml/badge.svg)](https://github.com/nixhantb/Rinzo/actions/workflows/codeql.yml)
[![RinzoCI](https://github.com/nixhantb/Rinzo/actions/workflows/rinzo-ci.yml/badge.svg)](https://github.com/nixhantb/Rinzo/actions/workflows/rinzo-ci.yml)

# Introduction

Rinzo is a recruitment platform exposed through an ASP.NET Web API. Seekers and employers use account and profile endpoints; companies publish job records, and seekers submit applications that can be queried with related company, job, and status details. Controllers delegate CRUD work through repository contracts to EF Core contexts.

Five resources make up the domain: Companies, Employers, Jobs, Seekers, and Applications. Create/Read is wired up across all of them; Update/Delete endpoints exist on every resource but are being filled in one repository at a time.

[![Architecture diagram of nixhantb/rinzo](https://gitdiagram.com/nixhantb/rinzo/diagram.png)](https://gitdiagram.com/nixhantb/rinzo?utm_source=readme&utm_medium=picture)

## Running locally

```bash
docker compose up --build
```

See `.env.example` for the required environment variables.
