import { JosenBugTemplatePage } from './app.po';

describe('JosenBug App', function() {
  let page: JosenBugTemplatePage;

  beforeEach(() => {
    page = new JosenBugTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
