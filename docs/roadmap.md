# Portfolio CV roadmap

## Goal

Build a strong first portfolio CV for `ulfbou.github.io`. Extend it later with small, contract-driven tools that collect repository information and use optional LLM assistance to propose reviewable portfolio material.

## Shared gates

A phase is **Acceptance Ready** when its bounded implementation is complete, mandatory validation passes, every criterion has named evidence, limitations are recorded, no blocking defect remains, and the result can be evaluated without later phases.

A phase is **Done** when its Acceptance Ready result is accepted, documentation matches implementation, no undocumented workaround is required, semantic non-regression passes, and the repository is coherent for the next phase.

## Phase 1: Rapid portfolio vertical slice

**Outcome:** a deployable and already useful portfolio CV shell.

Acceptance Ready requires:

- successful static build and GitHub Pages configuration;
- meaningful `/`, `/cv`, `/portfolio`, `/portfolio/{slug}`, and `/print/cv` routes;
- homepage introduction, direction, competence, selected projects, and clear navigation;
- CV profile, experience, education, competence, projects, contact, and links;
- portfolio index and two representative project pages using temporary approved in-repository data;
- intentional unknown-slug behavior;
- usable mobile, desktop, keyboard, heading, focus, accessible-name, and print behavior;
- direct-route refresh support;
- no dependency on collectors, LLMs, authentication, server hosting, or authoring tools.

Done additionally requires deployed verification, accurate approved representation of KTH and Stockholm University, junior architecture described as a direction, screen and print review, and no placeholder public claims.

## Phase 2: Structured content and validation

**Outcome:** approved structured content drives every public view.

Acceptance Ready requires:

- versioned contracts for profile, employment, education, project, technology, snippet, evidence, link, relationship, and publication metadata;
- stable IDs and validated references;
- explicit `overview`, `detail`, and `evidence` reading depths;
- distinguishable authored, repository-derived, LLM-suggested, reviewed, and published origins or states;
- deterministic compilation from `src/content/` to generated runtime JSON;
- public filtering that excludes candidates and private-build-only content;
- duplicate-ID, unknown-type/state, malformed-metadata, dangling-reference, and internal-route failures;
- at least two projects rendered from content without project-specific Razor pages;
- non-zero status for mandatory validation failure.

Done additionally requires one authority for public CV facts, documented valid and invalid fixtures, predictable failure behavior, provenance on derived public material, and no Phase 1 regression.

## Phase 3: Versatile editorial blocks

**Outcome:** reusable blocks compose narrative project case studies across screen and print.

Initial catalogue:

- `ProseBlock`
- `QuoteBlock`
- `CommentaryBlock`
- `CodeBlock`
- `TerminalBlock`
- `ImageBlock`
- `LinksBlock`
- `EvidenceBlock`
- `CalloutBlock`
- `RelatedContentBlock`

Acceptance Ready requires stable IDs, semantic types, accessible labels, reading depth, provenance, content-controlled order, required-property validation, screen and print rendering, contained fallback behavior, copyable code and terminal text, image alternatives, meaningful links, quotation attribution, and clear separation of reflection from evidence.

At least one project must coherently use five block types. Blocks not yet needed by real content may remain specified rather than implemented, but the first solid release must support prose, code or terminal, commentary, links, image, and evidence.

Done requires documented block contracts, repository-neutral rendering, verified accessibility and print policies, strict unknown-type rejection, resolvable related content, and no previous regression.

## Phase 4: First solid public portfolio

**Outcome:** a polished portfolio CV independent of all future automation.

Acceptance Ready requires:

- concise personal introduction and professional direction;
- approved KTH experience and Stockholm University studies;
- selected competence areas;
- two or three polished project case studies;
- each project covering purpose, motivation, personal contribution, demonstrated competence, evidence, learning, maturity, and explicit limitations;
- selected code or terminal material with human explanation;
- meaningful project, repository, source, test, documentation, and download links where relevant;
- progressive disclosure from overview to detail to evidence;
- printable CV derived from the same approved facts;
- no private data, placeholders, unsupported strengthening, dead links, or quantity-as-quality scoring.

Done requires Ulf's explicit content approval, coherent trajectory across pages, consistent desktop/mobile/print design, accessible comprehension, public deployment matching validated source, and the ability to add an ordinary project through content and existing blocks.

## Phase 5: Repository evidence package contract

**Outcome:** a small presentation-neutral boundary for future repository-derived candidates.

Acceptance Ready requires versioned input and output schemas for repository identity, revision, included and excluded scope, observations, snippet candidates, claim candidates, evidence candidates, technology candidates, warnings, and collector provenance. Every candidate retains bounded source references. Candidate, reviewed, and published states remain structurally distinct.

The contract must support partial results with explicit warnings, future extension fields, and consumption without repository or Blazor access. It must not contain presentation layout or grant publication authority.

Done requires fixtures, compatibility rules, schema tests, machine-readable exclusions, explicit missing evidence, and graceful portfolio operation when no evidence package exists.

## Phase 6: Minimal deterministic repository collector

**Outcome:** a CLI creates a reviewable evidence package for one selected project.

Start with only information needed by actual portfolio content:

- repository ID and revision;
- approved README and documentation headings;
- project and solution metadata;
- explicit language and framework indicators;
- sample, test, workflow, package, and release paths;
- bounded code-snippet candidates;
- conflicts, omissions, and collection warnings.

Acceptance Ready requires explicit repository, project ID, output sink, inclusion and exclusion rules, normalized paths, source references, non-zero mandatory failures, safe diagnostics, policies for binary/generated/oversized content, contract-valid output, and semantically equivalent output for equivalent input.

The collector must not judge quality, infer personal contribution, write final CV copy, select flattering evidence automatically, or modify approved portfolio content.

Done requires one real project package, exclusion proofs, normal/incomplete/conflicting fixtures, explicit partial markers, complete traceability, and an unchanged public portfolio until separate human review.

## Phase 7: LLM-assisted curation pilot

**Outcome:** one bounded evidence package can produce reviewable suggestions without becoming portfolio truth.

The pilot may group observations, propose concise summaries, suggest illustrative snippets, identify unsupported claims, rewrite approved facts for reading depth, find contradictions, or draft interview discussion points.

Acceptance Ready requires candidate ID, task type, evidence references, repository revision, prompt/configuration identity, original suggestion, review state, reviewer decision, and accepted edited value where applicable. It supports accept, accept-with-edits, and reject; preserves provenance after edits; filters excluded inputs; records insufficient evidence; and blocks direct publication.

Done requires one complete evidence-to-approved-content example, no unapproved public rendering, retained origins, excluded rejects, blocked unsupported claims, tested sensitive-input filtering, continued manual authoring without LLM availability, and clear separation between deterministic evidence and probabilistic suggestions.

## Phase 8: Evidence-led authoring tools

**Outcome:** add only the tools proven necessary by the collector and curation pilot.

Candidate capabilities include side-by-side review, snippet and line-range selection, claim-to-evidence association, repository-change inbox, stale-evidence detection, project preview, CV composition, approved-content comparison, provenance inspection, and publication preview.

Acceptance Ready requires the selected tools to use shared contracts, preserve IDs and provenance, separate drafts from publication, show blockers, respect exclusions and read-only evidence, validate before publication, and cancel without public change.

Done requires tool-authored content to pass the same validation as hand-authored content, no review bypass, faithful preview, surfaced staleness, semantic comparison, safe failure behavior, replaceable clients, public-site independence, documented authority boundaries, and all previous gates passing.

## Cross-phase non-regression gate

Acceptance Ready is blocked by unauthorized semantic loss; incorrect professional direction; planned or experimental work presented as implemented; lost provenance; unreviewed publication; exposure of excluded or private material; broken routes, print, accessibility, direct refresh, or core offline/static behavior; dependency on later optional tooling; unsupported marketing amplification; or unknown mandatory validation.

## Overall Definition of Done

The roadmap is complete when:

- the public portfolio is strong without collectors or LLMs;
- approved structured facts drive web and print;
- projects combine narrative, code, terminal material, quotations, commentary, images, links, and evidence as needed;
- overview remains human-readable while detail and evidence are progressively available;
- repository collection is bounded, deterministic, and traceable;
- LLM output remains an optional reviewable suggestion;
- Ulf remains final authority;
- tools extend shared contracts without redesigning or becoming prerequisites for the portfolio core;
- every accepted phase continues to pass its gates.
