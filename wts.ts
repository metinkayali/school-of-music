import { Pitch, Music, AbsPitch } from './types';
import { qn } from './constants';
import { pitch, absPitch } from './absolute-pitch';

export function wts(p: Pitch) {
  const f = (shift: AbsPitch): Music<Pitch> => ({
    primitive: {
      dur: qn,
      pitch: pitch(absPitch(p) + shift),
    }
  });
  return [0,2,4,6,8].map(f);
}