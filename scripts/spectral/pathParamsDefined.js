const OPERATIONS = ['get', 'put', 'post', 'delete', 'patch', 'options', 'head', 'trace'];

const decodePointerToken = token => token.replace(/~1/g, '/').replace(/~0/g, '~');

const resolveRef = (documentData, ref) => {
  if (typeof ref !== 'string' || !ref.startsWith('#/') || !documentData) {
    return null;
  }

  const tokens = ref
    .slice(2)
    .split('/')
    .map(decodePointerToken)
    .filter(Boolean);

  return tokens.reduce((node, token) => {
    if (node && typeof node === 'object' && token in node) {
      return node[token];
    }

    return undefined;
  }, documentData);
};

const collectPathParamNames = (params, definedNames, documentData) => {
  if (!Array.isArray(params)) {
    return;
  }

  for (const param of params) {
    if (!param || typeof param !== 'object') {
      continue;
    }

    if (typeof param.name === 'string' && param.in === 'path') {
      definedNames.add(param.name);
      continue;
    }

    if (typeof param.$ref === 'string') {
      const resolved = resolveRef(documentData, param.$ref);
      if (resolved && resolved.in === 'path' && typeof resolved.name === 'string') {
        definedNames.add(resolved.name);
      }
    }
  }
};

module.exports = (targetVal, _opts, context) => {
  const jsonPath = Array.isArray(context?.path) ? context.path : [];
  const pathKey = typeof jsonPath[jsonPath.length - 1] === 'string' ? jsonPath[jsonPath.length - 1] : undefined;

  if (!pathKey) {
    return;
  }

  const matches = [...pathKey.matchAll(/\{([^}]+)\}/g)].map((match) => match[1]).filter(Boolean);

  if (matches.length === 0) {
    return;
  }

  const uniquePlaceholders = [...new Set(matches)];
  const documentData = context?.document?.data;
  const definedNames = new Set();

  collectPathParamNames(targetVal?.parameters, definedNames, documentData);

  for (const operation of OPERATIONS) {
    collectPathParamNames(targetVal?.[operation]?.parameters, definedNames, documentData);
  }

  const missing = uniquePlaceholders.filter((name) => !definedNames.has(name));

  if (missing.length === 0) {
    return;
  }

  return [
    {
      message: `Paramètres de chemin manquants: ${missing.join(', ')}`,
      path: jsonPath,
    },
  ];
};
