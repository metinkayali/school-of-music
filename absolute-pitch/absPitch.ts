import {
  PitchClass, Pitch, AbsPitch,
} from './types';

function pitchClassToNum(pc: PitchClass) {
  switch (pc) {
    case 'Cff':
      return -2;
    case 'Cf':
      return -1;
    case 'C':
      return 0;
    case 'Cs':
      return 1;
    case 'Css':
      return 2;

    case 'Dff':
      return 0;
    case 'Df':
      return 1;
    case 'D':
      return 2;
    case 'Ds':
      return 3;
    case 'Dss':
      return 4;

    case 'Eff':
      return 2;
    case 'Ef':
      return 3;
    case 'E':
      return 4;
    case 'Es':
      return 5;
    case 'Ess':
      return 6;

    case 'Fff':
      return 3;
    case 'Ff':
      return 4;
    case 'F':
      return 5;
    case 'Fs':
      return 6;
    case 'Fss':
      return 7;

    case 'Gff':
      return 5;
    case 'Gf':
      return 6;
    case 'G':
      return 7;
    case 'Gs':
      return 8;
    case 'Gss':
      return 9;

    case 'Aff':
      return 7;
    case 'Af':
      return 8;
    case 'A':
      return 9;
    case 'As':
      return 10;
    case 'Ass':
      return 11;

    case 'Bff':
      return 9;
    case 'Bf':
      return 10;
    case 'B':
      return 11;
    case 'Bs':
      return 12;
    case 'Bss':
      return 13;
    default:
      return 0;
  }
}

export function absPitch(p: Pitch): AbsPitch {
  const n = pitchClassToNum(p.pitchClass);
  return (p.octave * 12) + n;
}

export default absPitch;