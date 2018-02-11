import pitch from './pitch';
import absPitch from './absPitch';
import { Pitch } from '../types';

export const trans = (n: number) => (p: Pitch) =>
  pitch(absPitch(p) + n);

export default trans;