# Content contract

## Envelope

Every compiled dataset contains:

```json
{
  "schemaVersion": "1.0",
  "generatedFrom": "authored-content",
  "items": []
}
```

Build reproducibility must not depend on volatile timestamps. If audit time is needed, keep it outside semantic comparison or inject it only in non-public build evidence.

## Common item fields

- `id`: stable, unique identifier
- `kind`: semantic entity or block type
- `state`: authored, repository-derived, llm-suggested, reviewed, or published
- `visibility`: public or private-build-only
- `provenance`: source references appropriate to origin
- `readingDepth`: overview, detail, or evidence
- `title` or `accessibleLabel`

## Publication rule

An item may enter generated public JSON only when its source is authorized for publication and all references resolve. A repository package cannot authorize itself. An LLM candidate cannot authorize itself. Approval evidence identifies the reviewer and decision.

## Core entities

Profile, employment, education, project, technology, snippet, evidence, link, and relationship entities use stable IDs. Project pages reference blocks by ID or contain validated ordered block records. Presentation components do not restate authoritative facts.

## Block contract

All blocks use `id`, `type`, optional `title`, `accessibleLabel`, `readingDepth`, provenance, and type-specific payload. Unknown types fail compilation. Rendering failures produce an explicit contained fallback in development and block publication validation.

## Links and references

Internal routes, project IDs, block IDs, technologies, evidence, snippets, and related content are validated as a graph. Dangling references fail the build. External link reachability is a release check, not a source-schema guarantee.

## Generated destinations

```text
src/Ulfbou.Site/wwwroot/data/generated/profile.json
src/Ulfbou.Site/wwwroot/data/generated/cv.json
src/Ulfbou.Site/wwwroot/data/generated/projects.json
src/Ulfbou.Site/wwwroot/data/generated/projects/{slug}.json
src/Ulfbou.Site/wwwroot/data/generated/navigation.json
```

Generated files are build artifacts. Changes originate in `src/content/`, never by hand-editing generated JSON.
