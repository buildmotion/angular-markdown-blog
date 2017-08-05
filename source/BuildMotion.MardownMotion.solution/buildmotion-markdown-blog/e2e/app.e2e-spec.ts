import { BuildmotionMarkdownBlogPage } from './app.po';

describe('buildmotion-markdown-blog App', () => {
  let page: BuildmotionMarkdownBlogPage;

  beforeEach(() => {
    page = new BuildmotionMarkdownBlogPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
