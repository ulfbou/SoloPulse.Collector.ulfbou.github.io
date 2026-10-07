# ulfbou.github.io portfolio CV

This repository builds `ulfbou.github.io` as a strong, extensible portfolio CV. The first release must work as a complete professional portfolio without repository collectors, LLM services, authoring tools, or runtime automation.

## Product intention

The site tells Ulf Bourelius's professional story first and makes supporting evidence available progressively. It presents his background, current direction, selected competence, projects, code, reflections, links, and evidence at three reading depths:

1. overview for fast orientation;
2. detail for project and engineering context;
3. evidence for visitors who want to verify claims.

Junior software architecture is a learning direction, not a currently held role. Public content must remain understandable when every technical or evidence panel is closed.

## Delivery strategy

1. ship a small, polished portfolio vertical slice;
2. move all public facts into validated structured content;
3. add versatile reusable blocks;
4. complete the first solid public release;
5. define a presentation-neutral repository evidence contract;
6. add a minimal deterministic collector only when it serves real portfolio content;
7. add optional LLM-assisted curation behind explicit human review;
8. add authoring tools only from demonstrated workflow needs.

## Baseline

- .NET 10 Blazor WebAssembly static site;
- GitHub Pages deployment;
- authored content under `src/content/`;
- generated public runtime data under `src/Ulfbou.Site/wwwroot/data/generated/`;
- deterministic build-time compilation and validation;
- YAML or JSON authoring selected by repository fit, with JSON as the runtime boundary;
- repository and LLM tooling kept optional and outside the public runtime.

## Authority

Ulf is the final state manager and publishing authority. Repository-derived and LLM-generated material is candidate state until explicitly reviewed and accepted. Tools may collect, organize, compare, and suggest. They may not invent, approve, or publish portfolio claims.

## Governing documents

1. `docs/roadmap.md`
2. `docs/prototype/rapid-prototype.md`
3. `docs/architecture/system.md`
4. `docs/contracts/content.md`
5. `docs/contracts/authority.md`
6. `docs/prototype/visual-system.md`
7. `docs/validation.md`
8. `docs/decisions.md`
