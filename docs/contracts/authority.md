# Authority, provenance, and publication

## Authority order

1. Ulf's explicit approval controls public factual content.
2. Approved authored content is the public source of truth.
3. Reviewed repository-derived material remains traceable to revision and source.
4. LLM output is a suggestion until explicitly reviewed.
5. Existing public content may not be weakened silently.

## Required provenance

Repository-derived content records repository ID, revision, source path or bounded source reference, source category, collector identity/version, and review evidence.

LLM-assisted content additionally records candidate ID, task type, evidence references, prompt/configuration identity, original generated value, decision, reviewer, and accepted edited value where relevant.

Personal commentary is labeled as reflection and must not masquerade as sourced evidence.

## Publication transition

```text
candidate -> reviewed -> approved source -> validated build -> public runtime data
```

Changing one status string is insufficient. The transition requires review evidence and complete validation.

## Non-regression

Comparison is semantic. Moving or rewriting content is allowed when facts, qualifications, authority, provenance, navigation, contracts, and accepted behavior are preserved or strengthened. Publication is blocked on unresolved loss, contradiction, unsupported strengthening, missing evidence, or unknown validation.
